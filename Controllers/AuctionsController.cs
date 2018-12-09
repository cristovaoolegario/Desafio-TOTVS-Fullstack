using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DesafioFullStackTotvs.Models;
using DesafioFullStackTotvs.Services;

namespace DesafioFullStackTotvs.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase {
        private IAuctionService _auctionService;

        public AuctionsController (IAuctionService auctionService) {
           _auctionService = auctionService;
        }

        [HttpGet]
        public ActionResult<List<Auction>> GetAll () {
            return _auctionService.GetAll().ToList();
        }

        [HttpGet ("{id}", Name = "GetAuction")]
        public ActionResult<Auction> GetById (long id) {
            var item = _auctionService.GetById(id);
            if (item == null) {
                return NotFound ();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create (Auction item) {
            _auctionService.Add(item);

            return CreatedAtRoute ("GetAuction", new { id = item.AuctionID }, item);
        }

        [HttpPut ("{id}")]
        public IActionResult Update (long id, Auction item) {
           _auctionService.Update(id, item);
            return NoContent ();
        }

        [HttpDelete ("{id}")]
        public IActionResult Delete (long id) {
            _auctionService.Delete(id);
            return NoContent ();
        }
    }
}