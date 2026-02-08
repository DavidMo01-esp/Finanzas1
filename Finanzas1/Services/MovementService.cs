using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finanzas1.Data;
using Finanzas1.Models;
using Microsoft.EntityFrameworkCore;

namespace Finanzas1.Services
{
    public class MovementService
    {
        public void SaveDB()
        {
            using var db = new FinanceContext();
            db.Database.EnsureCreated();
        }
        public void InsertMovement(Movement movement)
        {
            using var db = new FinanceContext();
            db.Movements.Add(movement);
            db.SaveChanges();
        }
        public List<Movement> TakeMovements()
        {
            using var db = new FinanceContext();
            return db.Movements
                .OrderByDescending(m => m.Date).
                ToList();
        }

        public decimal GetBalance()
        {
            using var db = new FinanceContext();
            return db.Movements.Sum(m => m.Type == MovementType.Income ? m.Quantity : -m.Quantity);
        }

    }
}
