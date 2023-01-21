using POS.Repository;
using Microsoft.AspNetCore.Mvc;
using POS.ViewModel;
using POS.ViewModel.Response;

namespace POS.Service
{
    public class OrderService
    {
        private readonly ApplicationDbContext _context;
        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        private OrderModel EntityOrderToModelOrder(OrderEntity entity)
        {
            OrderModel result = new OrderModel();
            result.Id = entity.Id;
            result.CustomerId = entity.CustomerId;
            result.EmployeeId = entity.EmployeeId;
            result.OrderDate = entity.OrderDate;
            result.RequiredDate = entity.RequiredDate;
            result.ShippedDate = entity.ShippedDate;
            result.ShipperId = entity.ShipperId;
            result.Freight = entity.Freight;
            result.ShipName = entity.ShipName;
            result.ShipAddress = entity.ShipAddress;
            result.ShipCity = entity.ShipCity;
            result.ShipRegion = entity.ShipRegion;
            result.ShipPostalCode = entity.ShipPostalCode;
            result.ShipCountry = entity.ShipCountry;
            foreach (var item in entity.OrderDetails)
            {
                result.OrderDetails.Add(EntityOrderDetailToModelOrderDetail(item));
            }

            return result;
        }

        private OrderEntity ModelOrderToEntityOrder(OrderModel model)
        {
            var entity = new OrderEntity();
            entity.CustomerId = model.CustomerId;
            entity.EmployeeId = model.EmployeeId;
            entity.OrderDate = model.OrderDate;
            entity.RequiredDate = model.RequiredDate;
            entity.ShippedDate = model.ShippedDate;
            entity.ShipperId = model.ShipperId;
            entity.Freight = model.Freight;
            entity.ShipName = model.ShipName;
            entity.ShipAddress = model.ShipAddress;
            entity.ShipCity = model.ShipCity;
            entity.ShipRegion = model.ShipRegion;
            entity.ShipPostalCode = model.ShipPostalCode;
            entity.ShipCountry = model.ShipCountry;
            entity.OrderDetails = new List<OrderDetailEntity>();
            foreach (var item in model.OrderDetails)
            {
                entity.OrderDetails.Add(ModelOrderDetailToEntityOrderDetail(item));
            }
            
            return entity;
        }

        private OrderDetailModel EntityOrderDetailToModelOrderDetail(OrderDetailEntity entity)
        {
            var model = new OrderDetailModel();
            model.Id = entity.Id;
            model.ProductId = entity.ProductId;
            model.UnitPrice = entity.UnitPrice;
            model.Quantity = entity.Quantity;
            model.Discount = entity.Discount;
            return model;
        }

        private OrderDetailEntity ModelOrderDetailToEntityOrderDetail(OrderDetailModel model)
        {
            var entity = new OrderDetailEntity();
            entity.OrderId = model.OrderId;
            entity.ProductId = model.ProductId;
            entity.UnitPrice = model.UnitPrice;
            entity.Quantity = model.Quantity;
            entity.Discount = model.Discount;
            return entity;
        }

        private OrderResponse EntityToModelResponseDetail(OrderEntity entity)
        {
            var customer = _context.Customers.Find(entity.CustomerId);
            var shipper = _context.Shippers.Find(entity.ShipperId);
            var response = new OrderResponse();
            response.Id = entity.Id;
            response.CustomerId = customer.Id;
            response.ContactName = customer.ContactName;
            response.OrderDate = entity.OrderDate;
            response.RequiredDate = entity.RequiredDate;
            response.ShippedDate = entity.ShippedDate;
            response.ShipperId = shipper.Id;
            response.ShipperName = shipper.CompanyName;
            response.ShipperPhone = shipper.Phone;
            response.Freight = entity.Freight;
            response.ShipName = entity.ShipName;
            response.ShipAddress = entity.ShipAddress;
            response.ShipCity = entity.ShipCity;
            response.ShipRegion = entity.ShipRegion;
            response.ShipPostalCode = entity.ShipPostalCode;
            response.ShipCountry = entity.ShipCountry;
            response.Details = new List<OrderDetailResponse>();
            foreach (var item in entity.OrderDetails)
            {
                response.Details.Add(EntityToModelDetailResponse(item));
            }

            var subtotal = 0.0;
            foreach (var item in response.Details)
            {
                item.Subtotal = item.Quantity * item.UnitPrice * (1 - item.Discount / 100);
                subtotal += item.Subtotal;
            }

            response.Subtotal = subtotal;
            response.Shipping = 0;
            response.Total = response.Subtotal + response.Shipping;
            return response;
        }

        private OrderDetailResponse EntityToModelDetailResponse(OrderDetailEntity entity)
        {
            var model = new OrderDetailResponse();
            var product = _context.Products.Find(entity.ProductId);
            model.Id = entity.Id;
            model.ProductId = product.Id;
            model.ProductName = product.ProductName;
            model.UnitPrice = entity.UnitPrice;
            model.Quantity = entity.Quantity;
            model.Discount = entity.Discount;
            return model;
        }

        //private void ModelToEntity(OrderModel model, OrderEntity entity)
        //{
        //    entity.CustomerId = model.CustomerId;
        //    entity.EmployeeId = model.EmployeeId;
        //    entity.OrderDate = model.OrderDate;
        //    entity.RequiredDate = model.RequiredDate;
        //    entity.ShippedDate = model.ShippedDate;
        //    entity.ShipperId = model.ShipperId;
        //    entity.Freight = model.Freight;
        //    entity.ShipName = model.ShipName;
        //    entity.ShipAddress = model.ShipAddress;
        //    entity.ShipCity = model.ShipCity;
        //    entity.ShipRegion = model.ShipRegion;
        //    entity.ShipPostalCode = model.ShipPostalCode;
        //    entity.ShipCountry = model.ShipCountry;
        //}

        public List<OrderEntity> GetOrders()
        {
            return _context.Orders.ToList();
        }

        public void AddOrder(OrderModel request)
        {
            //_context.Orders.Add(request);
            //_context.SaveChanges();

            var newData = ModelOrderToEntityOrder(request);
            _context.Orders.Add(newData);
            foreach (var item in newData.OrderDetails)
            {
                item.OrderId = request.Id;
                _context.OrderDetails.Add(item);
            }
            _context.SaveChanges();
        }

        public OrderModel GetOrderById(int? id)
        {
            //var order = _context.Orders.Find(id);
            //return EntityToModel(order);

            var order = _context.Orders.Find(id);
            var detail = _context.OrderDetails.Where(i => i.OrderId == id);
            foreach (var item in detail) { }
            return EntityOrderToModelOrder(order);
        }

        public OrderResponse ReadOrderInvoice(int? id)
        {
            var orderEntity = _context.Orders.Find(id);
            var detailEntity = _context.OrderDetails.Where(i => i.OrderId == id).ToList();
            orderEntity.OrderDetails = detailEntity;
            var orderResponse = EntityToModelResponseDetail(orderEntity);
            return orderResponse;
        }

        public void UpdateOrder(OrderModel order)
        {
            var entityOrder = _context.Orders.Find(order.Id);
            var orderDetailList = _context.OrderDetails.Where(i => i.OrderId == order.Id).ToList();
            var updatedEntity = ModelOrderToEntityOrder(order);

            entityOrder.CustomerId = updatedEntity.CustomerId;
            entityOrder.EmployeeId = updatedEntity.EmployeeId;
            entityOrder.OrderDate = updatedEntity.OrderDate;
            entityOrder.RequiredDate = updatedEntity.RequiredDate;
            entityOrder.ShippedDate = updatedEntity.ShippedDate;
            entityOrder.ShipperId = updatedEntity.ShipperId;
            entityOrder.Freight = updatedEntity.Freight;
            entityOrder.ShipName = updatedEntity.ShipName;
            entityOrder.ShipAddress = updatedEntity.ShipAddress;
            entityOrder.ShipCity = updatedEntity.ShipCity;
            entityOrder.ShipRegion = updatedEntity.ShipRegion;
            entityOrder.ShipPostalCode = updatedEntity.ShipPostalCode;
            entityOrder.ShipCountry = updatedEntity.ShipCountry;
            entityOrder.OrderDetails = updatedEntity.OrderDetails;

            _context.Orders.Update(entityOrder);
            foreach (var newItem in entityOrder.OrderDetails)
            {
                newItem.OrderId = order.Id;
                foreach (var item in orderDetailList)
                {
                    if (newItem.ProductId == item.ProductId)
                    {
                        item.ProductId = newItem.ProductId;
                        item.UnitPrice = newItem.UnitPrice;
                        item.Quantity = newItem.Quantity;
                        item.Discount = newItem.Discount;
                        _context.OrderDetails.Update(item);
                    }
                }
            }
            _context.SaveChanges();
        }

        public void DeleteOrderById(int? id)
        {
            //var order = _context.Orders.Find(id);
            //_context.Orders.Remove(order);
            //_context.SaveChanges();

            var order = _context.Orders.Find(id);
            _context.Orders.Remove(order);

            var detail = _context.OrderDetails.Where(_i => _i.Id == id);
            foreach (var item in detail)
            {
                _context.OrderDetails.Remove(item);
            }
            _context.SaveChanges();
        }
    }
}
