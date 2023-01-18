using POS.Repository;
using Microsoft.AspNetCore.Mvc;
using POS.ViewModel;

namespace POS.Service
{
    public class ShipperService
    {
        private readonly ApplicationDbContext _context;
        public ShipperService(ApplicationDbContext context)
        {
            _context = context;
        }

        private ShipperModel EntityToModel(ShipperEntity entity)
        {
            ShipperModel result = new ShipperModel();
            result.Id = entity.Id;
            result.CompanyName= entity.CompanyName;
            result.Phone = entity.Phone;
            return result;
        }

        private void ModelToEntity(ShipperModel model, ShipperEntity entity)
        {
            entity.CompanyName = model.CompanyName;
            entity.Phone = model.Phone;
        }

        public List<ShipperEntity> GetShippers()
        {
            return _context.Shippers.ToList();
        }

        public void AddShipper(ShipperEntity request)
        {
            _context.Shippers.Add(request);
            _context.SaveChanges();
        }

        public ShipperModel GetShipperById(int id)
        {
            var shipper = _context.Shippers.Find(id);
            return EntityToModel(shipper);
        }

        public void UpdateShipper(ShipperModel Shipper)
        {
            var entity = _context.Shippers.Find(Shipper.Id);
            ModelToEntity(Shipper, entity);
            _context.Shippers.Update(entity);
            _context.SaveChanges();
        }

        public void DeleteShipperById(int id)
        {
            var shipper = _context.Shippers.Find(id);
            _context.Shippers.Remove(shipper);
            _context.SaveChanges();
        }
    }
}
