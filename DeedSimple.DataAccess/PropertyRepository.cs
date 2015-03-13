using System;
using System.Collections.Generic;
using System.Linq;
using DeedSimple.DataAccess.Exceptions;
using DeedSimple.Domain;
using PagedList;

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

        /// <summary>
        /// Return a page of properties given the search terms, sort order, page number, and page size.
        /// </summary>
        /// <param name="sortOrder">The <see cref="PropertySortOrder"/> that determines the order of the returned properties.</param>
        /// <param name="searchString">Any full string that should be matched (partial matches will fail).</param>
        /// <returns>A <see cref="IPagedList"/> of Property objects.</returns>
        public IEnumerable<Property> GetPropertiesFiltered(PropertySortOrder sortOrder, string searchString = null)
        {
            var properties = from p in _context.Properties
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                properties = properties.Where(p => p.Description.Contains(searchString)
                                                || p.Road.Contains(searchString)
                                                || p.Town.Contains(searchString)
                                                || p.County.Contains(searchString)
                                                || p.PostCode.Contains(searchString)
                                                || p.TagLine.Contains(searchString));
            }

            switch (sortOrder)
            {
                case PropertySortOrder.TagLineDescending:
                    properties = properties.OrderByDescending(p => p.TagLine);
                    break;
                case PropertySortOrder.AskingPriceAscending:
                    properties = properties.OrderBy(p => p.AskingPrice);
                    break;
                case PropertySortOrder.AskingPriceDescending:
                    properties = properties.OrderByDescending(p => p.AskingPrice);
                    break;
                default:
                    properties = properties.OrderBy(p => p.TagLine);
                    break;
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
