﻿using Contracts;
using Entities;

namespace Data
{
    public class InMemoryDatabase : IDatabase
    {
        private static List<Ticket> _tickets = new List<Ticket>();

        public Ticket GetTicketById(int id)
        {
            return _tickets.FirstOrDefault(x => x.Id == id);
        }

        public List<Ticket> GetTickets()
        {
            return _tickets;
        }

        public int AddTicket(Ticket model)
        {
            model.Id = 1;
            if (_tickets.Any())
                model.Id = _tickets.Max(s => s.Id) + 1;
            _tickets.Add(model);
            return model.Id;
        }


        public bool AddTicketResponse(int ticketId, string ticketResponse)
        {
            var targetTicket = GetTicketById(ticketId);
            if (targetTicket != null)
            {
                targetTicket.TicketResponse = ticketResponse;
                return true;
            }

            else
                return false;
        }


        public bool DeleteTicket(int id)
        {
            var targetTicket = GetTicketById(id);

            if (targetTicket != null)
            {
                _tickets.Remove(targetTicket);
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
