using DAL.Repository.Abstractions;
using DAL.Repository.DataSourсes;
using DAL.Repository.EF;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Repositories
{
    public class HostessRepository : Repository<Hostess>, IRepository<Hostess>
    {
        public HostessRepository(AirportContext context) : base(context)
        {
        }
    }
}
