#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace OpenAccessKendoService.Assemblers
{
	using System;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using Telerik.OpenAccess;
	using OpenAccessKendoService.Dto;
	using OpenAccessKendoService.Converters;
	using OpenAccessKendoService;

			
	public partial interface IAssembler<TDto, TEntity>
	    where TEntity : class
	{
	    TDto Assemble(TEntity entity);
	    TEntity Assemble(TEntity entity, TDto dto);
	
	    IEnumerable<TDto> Assemble(IEnumerable<TEntity> entityList);
	    IEnumerable<TEntity> Assemble(IEnumerable<TDto> dtoList);
	}
	
	public abstract class Assembler<TDto, TEntity> : IAssembler<TDto, TEntity>
	    where TEntity : class
	{
	    public abstract TDto Assemble(TEntity domainEntity);
	    public abstract TEntity Assemble(TEntity entity, TDto dto);
	
	    public virtual IEnumerable<TDto> Assemble(IEnumerable<TEntity> domainEntityList)
	    {
	        List<TDto> dtos = Activator.CreateInstance<List<TDto>>();
	        foreach (TEntity domainEntity in domainEntityList)
	        {
	            dtos.Add(Assemble(domainEntity));
	        }
	        return dtos;
	    }
	
	    public virtual IEnumerable<TEntity> Assemble(IEnumerable<TDto> dtoList)
	    {
	        List<TEntity> domainEntities = Activator.CreateInstance<List<TEntity>>();
	        foreach (TDto dto in dtoList)
	        {
	            domainEntities.Add(Assemble(null, dto));
	        }
	        return domainEntities;
	    }
	}
	
	
	public partial interface IProductAssembler : IAssembler<ProductDto, Product>
	{ 
	
	}
	
	public partial class ProductAssemblerBase : Assembler<ProductDto, Product>
	{
		/// <summary>
	    /// Invoked after the ProductDto instance is assembled.
	    /// </summary>
	    /// <param name="dto"><see cref="ProductDto"/> The Dto instance.</param>
		partial void OnDTOAssembled(ProductDto dto);
	
		/// <summary>
	    /// Invoked after the Product instance is assembled.
	    /// </summary>
	    /// <param name="entity">The <see cref="Product"/> instance.</param>
		partial void OnEntityAssembled(Product entity);
		
	    public override Product Assemble(Product entity, ProductDto dto)
	    {
	        if (entity == null)
	        {
	            entity = new Product();
	        }
			
			entity.ProductID = dto.ProductID;
			entity.ProductName = dto.ProductName;
			entity.QuantityPerUnit = dto.QuantityPerUnit;
			entity.UnitPrice = dto.UnitPrice;
			entity.UnitsInStock = dto.UnitsInStock;
			entity.UnitsOnOrder = dto.UnitsOnOrder;
			entity.ReorderLevel = dto.ReorderLevel;
			entity.Discontinued = dto.Discontinued;
	        this.OnEntityAssembled(entity);
	        return entity;
	    }
	
	    public override ProductDto Assemble(Product entity)
	    {
	        ProductDto dto = new ProductDto();
	        
			ObjectKey key = KeyUtility.Instance.Create(entity);
			dto.DtoKey = KeyUtility.Instance.Convert(key);
			dto.ProductID = entity.ProductID;
			dto.ProductName = entity.ProductName;
			dto.QuantityPerUnit = entity.QuantityPerUnit;
			dto.UnitPrice = entity.UnitPrice;
			dto.UnitsInStock = entity.UnitsInStock;
			dto.UnitsOnOrder = entity.UnitsOnOrder;
			dto.ReorderLevel = entity.ReorderLevel;
			dto.Discontinued = entity.Discontinued;
			this.OnDTOAssembled(dto);
	        return dto;
	    }
		
	}
	
	public partial class ProductAssembler : ProductAssemblerBase, IProductAssembler
	{
	    
	}
}
#pragma warning restore 1591
