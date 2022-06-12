using Microsoft.EntityFrameworkCore;
using PreKolos2.Entities.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PreKolos2.Entities
{
    public class _ContextFireTruck : DbContext
    {
        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<FireTruck> FireTrucks { get; set; }
        public virtual DbSet<FireTruckAction> FireTruckActions { get; set; }

        public _ContextFireTruck(DbContextOptions<_ContextFireTruck> options) : base(options)
        {

        }

        public _ContextFireTruck()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FireTruckEfConfiguration).GetTypeInfo().Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ActionEfConfiguration).GetTypeInfo().Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FireTruckActionEfConfiguration).GetTypeInfo().Assembly);

            modelBuilder.Entity<Action>(a =>
            {
                a.HasData(
                        new Action { IdAction = 1, StartTime = new DateTime(2012, 8, 12), EndTime = new DateTime(2013, 8, 13), NeedSpecialEquipment = true },
                        new Action { IdAction = 2, StartTime = new DateTime(2013, 7, 12), EndTime = new DateTime(2014, 10, 13), NeedSpecialEquipment = true },
                        new Action { IdAction = 3, StartTime = new DateTime(2014, 6, 12), EndTime = new DateTime(2015, 9, 13), NeedSpecialEquipment = false }
                    );
            });
            modelBuilder.Entity<FireTruck>(a =>
            {
                a.HasData(
                        new FireTruck { IdFiretruck = 1, OperationNumber = "2137", SpecialEquipment = true },
                        new FireTruck { IdFiretruck = 2, OperationNumber = "69420", SpecialEquipment = true },
                        new FireTruck { IdFiretruck = 3, OperationNumber = "42069", SpecialEquipment = false }
                    );
            });
            modelBuilder.Entity<FireTruckAction>(a =>
            {
                a.HasData(
                        new FireTruckAction { IdFireTruck = 1, IdAction = 3, AssignmentDate = new DateTime(2018, 6, 15) },
                        new FireTruckAction { IdFireTruck = 2, IdAction = 2, AssignmentDate = new DateTime(2018, 7, 12) },
                        new FireTruckAction { IdFireTruck = 3, IdAction = 1, AssignmentDate = new DateTime(2018, 8, 13) }
                    );
            });
        }
    }
}

/*using Microsoft.EntityFrameworkCore;
using PreKolos2.Entities.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PreKolos2.Entities
{
    public class _ContextFireTruck : DbContext
    {
        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<FireTruck> FireTrucks { get; set; }
        public virtual DbSet<FireTruckAction> FireTruckActions { get; set; }

        public _ContextFireTruck(DbContextOptions<_ContextFireTruck> options) : base(options)
        {
            
        }

        public _ContextFireTruck()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(FireTruckEfConfiguration).GetTypeInfo().Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ActionEfConfiguration).GetTypeInfo().Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(FireTruckActionEfConfiguration).GetTypeInfo().Assembly);
            modelBuilder.Entity<Action>(a =>
            {
                a.HasData(
                        new Action { IdAction = 1, StartTime = new DateTime(2012, 8, 12), EndTime = new DateTime(2013, 8, 13), NeedSpecialEquipment = true },
                        new Action { IdAction = 2, StartTime = new DateTime(2013, 7, 12), EndTime = new DateTime(2014, 10, 13), NeedSpecialEquipment = true },
                        new Action { IdAction = 3, StartTime = new DateTime(2014, 6, 12), EndTime = new DateTime(2015, 9, 13), NeedSpecialEquipment = false }
                    );
            });
            modelBuilder.Entity<FireTruck>(a =>
            {
                a.HasData(
                        new FireTruck { IdFiretruck = 1, OperationNumber = "2137", SpecialEquipment = true },
                        new FireTruck { IdFiretruck = 2, OperationNumber = "69420", SpecialEquipment = true },
                        new FireTruck { IdFiretruck = 3, OperationNumber = "42069", SpecialEquipment = false }
                    );
            });
            modelBuilder.Entity<FireTruckAction>(a =>
            {
                a.HasData(
                        new FireTruckAction { IdFireTruck = 1, IdAction = 3, AssignmentDate = new DateTime(2018, 6, 15) },
                        new FireTruckAction { IdFireTruck = 2, IdAction = 2, AssignmentDate = new DateTime(2018, 7, 12) },
                        new FireTruckAction { IdFireTruck = 3, IdAction = 1, AssignmentDate = new DateTime(2018, 8, 13) }
                    );
            });
        }
    }
}*/