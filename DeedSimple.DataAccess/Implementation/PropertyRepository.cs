using System;
using System.Collections.Generic;
using System.Linq;
using DeedSimple.DataAccess.Exceptions;
using DeedSimple.DataAccess.Interface;
using DeedSimple.Domain;

namespace DeedSimple.DataAccess.Implementation
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
            //var user = _context.Users.Find(sellerId);
            //
            //if (user == null)
            //    throw new EntityNotFoundException(string.Format("Seller user with ID {0} does not exist.", sellerId));

            return _context.Properties.Where(prop => prop.SellerId.Equals(sellerId)).ToList();
        }

        public Offer GetOffer(long offerId)
        {
            var offer = _context.Offers.Find(offerId);

            if (offer == null)
                throw new EntityNotFoundException(string.Format("Offer with ID {0} does not exist.", offerId));

            return offer;
        }

        public List<Offer> GetOffersByBuyerId(string buyerId)
        {
            //var user = _context.Users.Find(buyerId);
            //
            //if (user == null)
            //    throw new EntityNotFoundException(string.Format("Buyer user with ID {0} does not exist.", buyerId));

            return _context.Offers.Where(offer => offer.BuyerId.Equals(buyerId)).ToList();
        }

        /// <summary>
        /// Return a page of properties given the search terms, sort order, page number, and page size.
        /// </summary>
        /// <param name="sortOrder">The <see cref="PropertySortOrder"/> that determines the order of the returned properties.</param>
        /// <param name="searchString">Any full string that should be matched (partial matches will fail).</param>
        /// <returns>An enumerable collection of Property objects.</returns>
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

        public long AddPropertyForUser(Property property)
        {
            var user = _context.Users.Find(property.SellerId);

            if (user == null || user.Type != UserType.Seller)
                throw new EntityNotFoundException(string.Format("Seller user {0} does not exist.", property.SellerId));

            var propertyOut = _context.Properties.Add(property);
            _context.SaveChanges();

            return propertyOut.Id;
        }

        public long PlaceOfferForProperty(Offer offer)
        {
            if (offer == null)
                throw new ArgumentNullException("offer");
            if (string.IsNullOrEmpty(offer.BuyerId))
                throw new ArgumentException("Offer must have a buyer user ID set.");

            var buyer = _context.Users.Find(offer.BuyerId);
            if (buyer == null || buyer.Type != UserType.Buyer)
                throw new EntityNotFoundException(string.Format("Buyer with ID {0} does not exist.", offer.BuyerId));

            var property = _context.Properties.Find(offer.PropertyId);
            if (property == null)
                throw new EntityNotFoundException(string.Format("Property with ID {0} does not exist.", offer.PropertyId));

            var offerOut = _context.Offers.Add(offer);
            property.OutstandingOffers.Add(offerOut);

            _context.SaveChanges();

            return offerOut.Id;
        }

        public bool PropertyCanBeEditedByUser(long propertyId, string userId)
        {
            var property = _context.Properties.Find(propertyId);
            return property != null && property.SellerId.Equals(userId);
        }

        public void CancelOffer(long offerId)
        {
            var offer = _context.Offers.Find(offerId);
            if (offer != null)
            {
                _context.Offers.Remove(offer);
                _context.SaveChanges();
            }
        }

        public void AcceptOffer(long offerId)
        {
            var offer = _context.Offers.Find(offerId);

            if (offer == null)
                throw new EntityNotFoundException(string.Format("Offer with ID {0} does not exist.", offerId));

            offer.State = OfferState.Accepted;
            _context.SaveChanges();
        }

        public void RejectOffer(long offerId)
        {
            var offer = _context.Offers.Find(offerId);

            if (offer == null)
                throw new EntityNotFoundException(string.Format("Offer with ID {0} does not exist.", offerId));

            offer.State = OfferState.Rejected;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
