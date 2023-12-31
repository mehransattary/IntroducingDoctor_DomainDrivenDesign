﻿using Doctor.Domain.MedicalServicesAgg;
using Doctor.Domain.MedicalServicesAgg.Repository;
using Doctor.Infrastructure._Utilities;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Doctor.Infrastructure.Persistent.Ef.MedicalServiceAgg;

public class MedicalServiceRepository : BaseRepository<MedicalService>, IMedicalServiceRepository
{
    private readonly DoctorContext _context;
    public MedicalServiceRepository(DoctorContext context) : base(context)
    {
        _context = context;
    }
    public async Task<bool> DeleteMedicalService(long medicalServiceidId)
    {
        var medicalService = await _context.MedicalServices
           .FirstOrDefaultAsync(f => f.Id == medicalServiceidId);
        if (medicalService == null)
            return false;
        _context.RemoveRange(medicalService);
        return true;
    }

 
}
