﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SyllabusManager.Data.Models;
using SyllabusManager.Logic.Services.Abstract;
using System.Threading.Tasks;

namespace SyllabusManager.API.Controllers.Abstract
{
    [Authorize]
    public abstract class ModelBaseControllerBase<T> : ApiControllerBase where T : ModelBase
    {
        private readonly IModelBaseService<T> _modelService;

        public ModelBaseControllerBase(IModelBaseService<T> crudService)
        {
            _modelService = crudService;
        }
        [HttpPost]
        public virtual async Task<IActionResult> Add([FromBody] T entity)
        {
            T result = await _modelService.AddAsync(entity);
            if (result == null)
            {
                return BadRequest();
            }
            return Created(result.Id.ToString(), result);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual async Task<IActionResult> ById(string id)
        {
            T result = await _modelService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
