﻿using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.TeamRepositories
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(OnlineTeamScanContext context) : base(context)
        { }

        public Team GetFullTeamById(int id)
        {
            return _dbSet.Include(team => team.TeamMembers).Include(team =>team.Teamscans).Include(team => team.Teamleader).Where(x => x.Id == id).FirstOrDefault();
        }

        public Team GetTeamIncludingTeamMembersById(int id)
        {
            return _dbSet.Include(team => team.TeamMembers).Where(team => team.Id == id).FirstOrDefault();
        }

        public IEnumerable<Team> GetAllTeamsByUser(int userId)
        {
            return GetAll(team => team.TeamleaderId == userId);
        }

        public IEnumerable<Team> GetAllActiveTeamsByUser(int userId)
        {
            return _dbSet.Include(team => team.Teamscans).Include(team => team.Teamleader).Where(team => team.TeamleaderId == userId && team.IsTeamscanActive == true);
        }

        public IEnumerable<Team> GetAllTeamsByUserIncludingTeamMembers(int userId)
        {
            return GetAll(filter: team => team.TeamleaderId == userId, includeProperties: x => x.TeamMembers);
        }

        public IEnumerable<Team> GetAllTeamsByUserIncludingTeamscans(int userId)
        {
            return GetAll(filter: team => team.TeamleaderId == userId, includeProperties: x => x.Teamscans);
        }

        public IEnumerable<Team> GetAllTeamsByUserIncludingTeamscansSorted(int userId)
        {
            return GetAll(filter: team => team.TeamleaderId == userId, orderBy: team => team.OrderBy(x => x.LastTeamScan) ,includeProperties: x => x.Teamscans);
        }

        public Team UpdateTeamName(Team team)
        {
            var entry = _context.Entry(team);
            entry.Property(x => x.Name).IsModified = true;

            return entry.Entity;
        }

        public Team UpdateIsTeamscanActive(Team team)
        {
            team.IsTeamscanActive = true;
            var entry = _context.Entry(team);
            entry.Property(x => x.IsTeamscanActive).IsModified = true;

            return entry.Entity;
        }

        public Team UpdateLastTeamscanOfTeam(Team team)
        {
            var entry = _context.Entry(team);
            entry.Property(x => x.IsTeamscanActive).IsModified = true;
            entry.Property(x => x.LastTeamScan).IsModified = true;

            return entry.Entity;
        }
    }
}
