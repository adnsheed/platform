using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Platform.Core.Entities;
using Platform.Core.Interfaces;
using Platform.Core.Requests.Admin;
using Platform.Database;

namespace Platform.Services
{
    public class AdminService : IAdminService
    {
        private readonly IMapper mapper;
        private readonly PlatformDbContext context;

        public AdminService(IMapper mapper, PlatformDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<ServiceResponse<Report>> Report()
        {
            var overallSuccess = await context.OverallSuccesses.FromSqlRaw("OverallSuccess").ToListAsync();
            var selectionSuccess = await context.SelectionSuccesses.FromSqlRaw("SelectionsSuccess").ToListAsync();

            var report = new Report();

            report.OverallSuccessRate = overallSuccess.First().OverallSuccessRate;
            report.SelectionSuccessesRate = selectionSuccess;

            return new ServiceResponse<Report>
            {
                Data = report
            };
        }
    }
}
