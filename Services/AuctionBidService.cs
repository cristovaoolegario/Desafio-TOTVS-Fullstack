using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using DesafioFullStackTotvs.Models;
using DesafioFullStackTotvs.Helpers;

namespace DesafioFullStackTotvs.Services
{
    public interface IAuctionBidService
    {        
        IEnumerable<AuctionBid> GetAll();
        AuctionBid GetById(long id);
        void Add(AuctionBid auction);
        void Update(long id, AuctionBid item);
        void Delete(long id);
    }

    public class AuctionBidService : IAuctionBidService
    {
        private readonly DesafioFullStackTotvsDataContext _context;
        private readonly AppSettings _appSettings;
        
        private List<AuctionBid> _auctionBids = new List<AuctionBid>();        

        public AuctionBidService(IOptions<AppSettings> appSettings, DesafioFullStackTotvsDataContext context)
        {
            _context = context;
            if (_context.AuctionBids.Count () == 0) {
                _context.AuctionBids.Add (new AuctionBid { BidPrice = 12 });
                _context.SaveChanges ();
            }
            _appSettings = appSettings.Value;
            _auctionBids.AddRange(_context.AuctionBids.ToList());
        }        

        public IEnumerable<AuctionBid> GetAll()
        {
            // return users without passwords
            return _auctionBids.ToList();
        }

        public AuctionBid GetById(long id){
            var item = _context.AuctionBids.Find (id);
            if (item == null) {
                return null;
            }
            return item;
        }

        public void Add(AuctionBid auctionBid){
             _context.AuctionBids.Add (auctionBid);
            _context.SaveChanges ();
        }

        public void Update(long id, AuctionBid auctionBid){
            var AuctionBid = _context.AuctionBids.Find (id);
            if (AuctionBid != null) 
            {
                AuctionBid.BidPrice = auctionBid.BidPrice;

                _context.AuctionBids.Update (AuctionBid);
                _context.SaveChanges ();
            }
        }

        public void Delete(long id){
            var AuctionBids = _context.AuctionBids.Find (id);
            if (AuctionBids != null) {
                _context.AuctionBids.Remove (AuctionBids);
                _context.SaveChanges ();
            }
        }
    }
}