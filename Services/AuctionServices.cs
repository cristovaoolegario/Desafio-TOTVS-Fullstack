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
    public interface IAuctionService
    {        
        IEnumerable<Auction> GetAll();
        Auction GetById(long id);
        void Add(Auction auction);
        void Update(long id, Auction item);
        void Delete(long id);
    }

    public class AuctionService : IAuctionService
    {
        private readonly DesafioFullStackTotvsDataContext _context;
        private readonly AppSettings _appSettings;
        
        private List<Auction> _auctions = new List<Auction>();        

        public AuctionService(IOptions<AppSettings> appSettings, DesafioFullStackTotvsDataContext context)
        {
            _context = context;
            if (_context.Auctions.Count () == 0) {
                _context.Auctions.Add (new Auction { Name = "Item2", UserId = "2", InitialValue = (long) 1200.00, WasUsed = "false" });
                _context.SaveChanges ();
            }
            _appSettings = appSettings.Value;
            _auctions.AddRange(_context.Auctions.ToList());
        }        

        public IEnumerable<Auction> GetAll()
        {
            // return users without passwords
            return _auctions.ToList();
        }

        public Auction GetById(long id){
            var item = _context.Auctions.Find (id);
            if (item == null) {
                return null;
            }
            return item;
        }

        public void Add(Auction auction){
             _context.Auctions.Add (auction);
            _context.SaveChanges ();
        }

        public void Update(long id, Auction auction){
            var Auction = _context.Auctions.Find (id);
            if (Auction != null) 
            {
                Auction.InitialValue = auction.InitialValue;
                Auction.Name = auction.Name;
                Auction.OpeningDate = auction.OpeningDate;
                Auction.TerminationDate = auction.TerminationDate;
                Auction.WasUsed = auction.WasUsed;
                Auction.UserId = auction.UserId;

                _context.Auctions.Update (Auction);
                _context.SaveChanges ();
            }
        }

        public void Delete(long id){
            var Auction = _context.Auctions.Find (id);
            if (Auction != null) {
                _context.Auctions.Remove (Auction);
                _context.SaveChanges ();
            }
        }
    }
}