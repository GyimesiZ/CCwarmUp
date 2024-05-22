using DevopsApi.Data;
using DevopsApi.Models.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Web.Http.Results;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Diagnostics.Metrics;
using System.Reflection;
using CCapi.Models.CodingChallenge;

namespace DevopsApi.Controllers.SharedDesk
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CCcontroller : ControllerBase
    {
        #region Private Fields
        private readonly DataContext _context;
        #endregion

        #region Public Fields
        #endregion

        #region Private Properties
        #endregion

        #region Public Properties
        #endregion

        #region Constructors
        public CCcontroller(DataContext context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods


        //Beléptetés: api/CCapi/Login/bela.kovacs@semilab.hu
        [HttpPost("{email}")]
        public async Task<ActionResult<CC_LoginFeedback>> Login(string email)
        {
            if (_context.Players is null)
            {
                return NotFound();
            }
            CC_LoginFeedback result = new();
            var user = await _context.Players.Include(u => u.Bets).Include(u => u.Messages).Where(u => u.UserName.ToLower() == email.ToLower()).FirstOrDefaultAsync();
            if (user is null)
            {
                result.Etc = "A felhasználó nincs regisztrálva";
                return result;
            }
            result.Id = user.Id;
            result.Name = user.DisplayName;
            result.Avatar = user.Avatar;
            result.InGame = user.InGame;
            result.Score = user.Score;
            result.Stake = user.Stake;
            foreach (var match in _context.Matches.OrderBy(m => m.Start))
            {
                switch (match.State)
                {
                    case MatchState.Completed:
                        Result matchResult = new();
                        matchResult.HomeTeam = _context.Teams.Where(t => t.Id == match.HomeId).FirstOrDefault();
                        matchResult.AwayTeam = _context.Teams.Where(t => t.Id == match.AwayId).FirstOrDefault();
                        matchResult.HomeGoals = match.HomeGoals;
                        matchResult.AwayGoals = match.AwayGoals;
                        matchResult.Playoff = match.Playoff;
                        if (match.Playoff)
                        {
                            matchResult.Winner = _context.Teams.Where(t => t.Id == match.Winner).FirstOrDefault();
                            matchResult.Shootout = match.Shootout;
                        }
                        var myBet = _context.Bets.Where(b => b.BetMakerId == user.Id && b.State == BetState.Expired && b.MatchId == match.Id).FirstOrDefault();
                        if (myBet != null)
                        {
                            matchResult.BetHomeGoals = myBet.HomeGoals;
                            matchResult.BetAwayGoals = myBet.AwayGoals;
                            matchResult.Score = myBet.Score;
                        }
                        result.Results.Add(matchResult);
                        break;
                }
            }
            return result;
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
