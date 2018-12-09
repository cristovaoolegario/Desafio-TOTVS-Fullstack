using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DesafioFullStackTotvs.Services;
using DesafioFullStackTotvs.Models;

namespace DesafioFullStackTotvs.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class AuctionBidsController : ControllerBase {
        private readonly IAuctionBidService _auctionBidsService;

        public AuctionBidsController (IAuctionBidService auctionBidsService) {
            _auctionBidsService = auctionBidsService;           
        }

        [HttpGet]
        public ActionResult<List<AuctionBid>> GetAll () {
            return _auctionBidsService.GetAll().ToList();
        }

        [HttpGet ("{id}", Name = "GetAuctionBid")]
        public ActionResult<AuctionBid> GetById (long id) {
            return _auctionBidsService.GetById(id);
        }

        [HttpPost]
        public IActionResult Create (AuctionBid item) {
            _auctionBidsService.Add(item);
            return CreatedAtRoute ("GetAuctionBid", new { id = item.AuctionBidID }, item);
        }

        [HttpPut ("{id}")]
        public IActionResult Update (long id, AuctionBid item) {
            _auctionBidsService.Update(id, item);
            return NoContent ();
        }

        [HttpDelete ("{id}")]
        public IActionResult Delete (long id) {
            _auctionBidsService.Delete(id);
            return NoContent ();
        }
    }
}