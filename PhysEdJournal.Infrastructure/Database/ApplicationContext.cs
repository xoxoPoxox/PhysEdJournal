﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PhysEdJournal.Core.Entities.DB;

namespace PhysEdJournal.Infrastructure.Database;

public sealed class ApplicationContext : DbContext
{
    public DbSet<GroupEntity> Groups { get; set; } = null!;
    public DbSet<PointsStudentHistoryEntity> PointsStudentsHistory { get; set; } = null!;
    public DbSet<VisitStudentHistoryEntity> VisitsStudentsHistory { get; set; } = null!;
    public DbSet<StandardsStudentHistoryEntity> StandardsStudentsHistory { get; set; } = null!;
    public DbSet<StudentEntity> Students { get; set; } = null!;
    public DbSet<TeacherEntity> Teachers { get; set; } = null!;
    public DbSet<ArchivedStudentEntity> ArchivedStudents { get; set; } = null!;
    public DbSet<SemesterEntity> Semesters { get; set; } = null!;

    public DbSet<CompetitionEntity> Competitions { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<ArchivedStudentEntity>()
            .HasKey(s => new { s.StudentGuid, s.SemesterName });

        base.OnModelCreating(modelBuilder);
    }

    public async ValueTask<SemesterEntity> GetActiveSemester()
    {
        return await Semesters.Where(s => s.IsCurrent).SingleAsync();
    }
}
