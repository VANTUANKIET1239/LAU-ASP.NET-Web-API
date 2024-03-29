﻿using AutoMapper;
using DoAnLau_API.Data;
using DoAnLau_API.Interface;
using DoAnLau_API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoAnLau_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuResponsitory _menuResponsitory;
        private readonly IMapper _mapper;
        private readonly IPageResponsitory _pageResponsitory;

        public MenuController(IMenuResponsitory menuResponsitory, IMapper mapper, IPageResponsitory pageResponsitory)
        {
            this._menuResponsitory = menuResponsitory;
            this._mapper = mapper;
            this._pageResponsitory = pageResponsitory;
        }
        [HttpGet,Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetMenus()
        {
            var menus = await _menuResponsitory.GetMenus();
            if (menus == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<MenuDTO>>(menus));

        }
        [HttpGet("{menuId}")]
        public async Task<IActionResult> GetMenu([FromRoute]string menuId)
        {
            if (!await _menuResponsitory.IsMenuExists(menuId))
            {
                return NotFound();
            }
            var menu = await _menuResponsitory.GetMenu(menuId);
            if (menu == null) return BadRequest();
            return Ok(_mapper.Map<MenuDTO>(menu));

        }
        [HttpGet("MenuCategory/{menuCategoryId}")]
        public async Task<IActionResult> GetMenuByMenuCategoryId(string menuCategoryId)
        {
            var menu = await _menuResponsitory.GetMenusByMenuCategoryId(menuCategoryId);
            if (menu == null) return BadRequest();
            return Ok(_mapper.Map<List<MenuDTO>>(menu));

        }
        [HttpPost("AddMenu")]
        public async Task<IActionResult> AddMenu([FromQuery]string MenuCategoryId,[FromBody]MenuDTO menu)
        {
            if(menu == null) return NotFound();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var menumap = _mapper.Map<Menu>(menu);
            if(! await _menuResponsitory.AddMenu(MenuCategoryId, menumap))
            {
                return StatusCode(500, ModelState);
            }
            return Ok(new {success = true});
        }
        [HttpPost("EditMenu")]
        public async Task<IActionResult> EditMenu([FromQuery] string MenuCategoryId, [FromBody] MenuDTO menu)
        {
            if (menu == null) return NotFound();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var menumap = _mapper.Map<Menu>(menu);
            if (!await _menuResponsitory.EditMenu(MenuCategoryId, menumap))
            {
                return StatusCode(500, ModelState);
            }
            return Ok(new { success = true });
        }
        [HttpPost("RemoveMenu")]
        public async Task<IActionResult> RemoveMenu([FromBody]MenuDTO menu)
        {
            if (menu == null) return NotFound();
            if (!await _menuResponsitory.RemoveMenu(menu.menu_Id))
            {
                return StatusCode(500, ModelState);
            }
            return Ok(new { success = true });
        }
        [HttpGet("Menu_GetHotDealItems")]
        public async Task<IActionResult> Menu_GetHotDealItems()
        {
            var menus = await _menuResponsitory.Menu_GetHotDealItems();
            if (menus == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<MenuDTO>>(menus));
        }

        [HttpGet("Menu_GetBestSellerItems")]
        public async Task<IActionResult> Menu_GetBestSellerItems()
        {
            var menus = await _menuResponsitory.Menu_GetBestSellerItems();
            if (menus == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<MenuDTO>>(menus));
        }
    }
}
