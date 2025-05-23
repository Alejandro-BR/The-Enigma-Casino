﻿
using Microsoft.AspNetCore.Mvc;
using the_enigma_casino_server.Application.Services;
using the_enigma_casino_server.Application.Dtos;

namespace the_enigma_casino_server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GachaponController : BaseController
{
    GachaponService _gachaponService;

    public GachaponController(GachaponService gachaponService)
    {
        _gachaponService = gachaponService;
    }

    [HttpGet("price")]
    public ActionResult<int> GetGachaponPrice()
    {
        try
        {
            return Ok(_gachaponService.GetGachaponPrice());
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Un error ha ocurrido al enviar su petición.");
        }
    }

    [HttpPost("play")]
    public async Task<ActionResult<GachaponResultDto>> Gachapon()
    {
        try
        {
            int userId = GetUserId();
            GachaponResultDto result = await _gachaponService.Gachapon(userId);
            return Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (UnauthorizedAccessException uae)
        {
            return BadRequest(uae.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Un error ha ocurrido al enviar su petición.");
        }
    }
}
