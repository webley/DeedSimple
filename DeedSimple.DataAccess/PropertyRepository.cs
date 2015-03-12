using System;
using System.Collections.Generic;
using System.Linq;
using DeedSimple.DataAccess.Exceptions;
using DeedSimple.Domain;

namespace DeedSimple.DataAccess
{
    public class PropertyRepository : IPropertyRepository, IDisposable
    {
        private readonly DeedSimpleContext _context;

        public PropertyRepository(DeedSimpleContext context)
        {
            _context = context;
        }

        public List<Property> GetPropertiesBySellerId(string sellerId)
        {
            List<Property> properties = null;
            var user = _context.SellerUsers.FirstOrDefault(u => u.Id == sellerId);

            if (user != null)
            {
                properties = _context.Properties.Where(prop => user.Properties
                    .Select(userProp => userProp.Id)
                    .Contains(prop.Id))
                    .ToList();
            }

            return properties;
        }

        public Property GetProperty(long propertyId)
        {
            var property = _context.Properties.Find(propertyId);

            if (property == null)
                throw new EntityNotFoundException(string.Format("Property with ID {0} does not exist.", propertyId));

            return property;
        }

        public List<Property> GetProperties(IEnumerable<long> propertyIds)
        {
            var properties = _context.Properties.Where(prop => propertyIds.Contains(prop.Id));
            var missingProperties = propertyIds.Where(id => _context.Properties.Find(id) == null);

            if (missingProperties.Any())
            {
                throw new EntityNotFoundException(string.Format("Properties with the following IDs do not exist: {0}", string.Join(", ", missingProperties)));
            }

            return properties.ToList();
        }

        public long AddPropertyForUser(string sellerId, Property property)
        {
            var user = _context.SellerUsers.Find(sellerId);

            if (user == null)
                throw new EntityNotFoundException(string.Format("Seller user {0} does not exist.", sellerId));

            user.Properties.Add(property);
            var propertyOut = _context.Properties.Add(property);
            _context.SaveChanges();

            return propertyOut.Id;
        }

        public long MakeOfferForProperty(string buyerUserId, Offer offer)
        {
            if (string.IsNullOrEmpty(buyerUserId))
                throw new ArgumentNullException("buyerUserId");
            if (offer == null)
                throw new ArgumentNullException("offer");

            var buyer = _context.BuyerUsers.Find(buyerUserId);
            if (buyer == null)
                throw new EntityNotFoundException(string.Format("Buyer with ID {0} does not exist.", buyerUserId));

            var property = _context.Properties.Find(offer.PropertyId);
            if (property == null)
                throw new EntityNotFoundException(string.Format("Property with ID {0} does not exist.", offer.PropertyId));

            var offerOut = _context.Offers.Add(offer);
            buyer.Offers.Add(offerOut);
            _context.SaveChanges();

            return offerOut.Id;
        }

        public bool PropertyCanBeEditedByUser(long propertyId, string userId)
        {
            var user = _context.SellerUsers.Find(userId);
            if (user != null)
            {
                return user.Properties.Select(prop => prop.Id).Contains(propertyId);
            }

            return false;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
