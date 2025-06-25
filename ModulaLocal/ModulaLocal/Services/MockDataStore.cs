//using ModulaLocal.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ModulaLocal.Services
//{
//    public class MockDataStore : IDataStore<BorrowTicket>
//    {
//        readonly List<BorrowTicket> items;

//        public MockDataStore()
//        {
//            items = new List<BorrowTicket>()
//            {
//                new BorrowTicket { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
//                new BorrowTicket { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
//                new BorrowTicket { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
//                new BorrowTicket { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
//                new BorrowTicket { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
//                new BorrowTicket { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
//            };
//        }

//        public async Task<bool> AddItemAsync(BorrowTicket item)
//        {
//            items.Add(item);

//            return await Task.FromResult(true);
//        }

//        public async Task<bool> UpdateItemAsync(BorrowTicket item)
//        {
//            var oldItem = items.Where((BorrowTicket arg) => arg.Id == item.Id).FirstOrDefault();
//            items.Remove(oldItem);
//            items.Add(item);

//            return await Task.FromResult(true);
//        }

//        public async Task<bool> DeleteItemAsync(string id)
//        {
//            var oldItem = items.Where((BorrowTicket arg) => arg.Id == id).FirstOrDefault();
//            items.Remove(oldItem);

//            return await Task.FromResult(true);
//        }

//        public async Task<BorrowTicket> GetItemAsync(string id)
//        {
//            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
//        }

//        public async Task<IEnumerable<BorrowTicket>> GetItemsAsync(bool forceRefresh = false)
//        {
//            return await Task.FromResult(items);
//        }
//    }
//}