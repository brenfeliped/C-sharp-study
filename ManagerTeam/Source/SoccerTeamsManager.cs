using System;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Exceptions;
using Source;

namespace Codenation.Challenge
{
    public class SoccerTeamsManager : IManageSoccerTeams
    {
        private List<Team>  _teams = new List<Team>();

        private List<Player> _players = new List<Player>();


        public SoccerTeamsManager()
        {
        }

        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor) {

           
          
            if (_teams.Select(x => x.id).Contains(id)){

                throw new Exceptions.UniqueIdentifierException();
            }
            else {

                _teams.Add(new Team(id,name,createDate,mainShirtColor,secondaryShirtColor));

            }
        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {

            if( _teams.Select(x => x.id).Contains(teamId)) {

                if (_players.Select(x => x.id).Contains(id))
                {

                    throw new Exceptions.UniqueIdentifierException();
                }
                else {

                    _players.Add(new Player(id,teamId,name,birthDate,skillLevel,salary));
                }
            }
            else {

                throw new Exceptions.TeamNotFoundException();
            }
        }

        public void SetCaptain(long playerId)
        {
            try
            {
                List<Player> playerCaptain = _players.Where(x => x.id == playerId).ToList();

                List<Team> teamCaptain = _teams.Where(x => x.id == playerCaptain[0].teamId).ToList();

                teamCaptain[0].IdCaptain = playerId;
            }
            catch (Exception) {

                throw new Exceptions.PlayerNotFoundException();
            }
           
        }

        public long GetTeamCaptain(long teamId)
        {
          
            List<Team> teamCaptain = _teams.Where(x => x.id == teamId).ToList();
            if (teamCaptain.Count == 0)
            {
                throw new Exceptions.TeamNotFoundException();
            }
            else
            {
                if (teamCaptain[0].IdCaptain != null)
                {

                    return (long)teamCaptain[0].IdCaptain;
                }
                else
                {
                    throw new Codenation.Challenge.Exceptions.CaptainNotFoundException();
                }
            }
 
        } 

        public string GetPlayerName(long playerId)
        {
            try
            {
                List<Player> playerRecord = _players.Where(x => x.id == playerId).ToList();
                return playerRecord[0].name;
            }
            catch (Exception) {

                throw new Exceptions.PlayerNotFoundException();
            }
        }

        public string GetTeamName(long teamId)
        {
            try
            {
                List<Team> team = _teams.Where(x => x.id == teamId).ToList();
                return team[0].name;
            }
            catch (Exception) {
                throw new Exceptions.TeamNotFoundException();
            }
        }

        public List<long> GetTeamPlayers(long teamId)
        {
            try
            {
                List<long> idsTeams = _teams.Select(x => x.id)
                .ToList();

                if ( !idsTeams.Contains(teamId)) {
                    throw new Exceptions.TeamNotFoundException();
                }

                List<Player> players = _players.Where(x => x.teamId == teamId).ToList();
                List<long> idPlayersList = players.Select(x => x.id).ToList();
                idPlayersList.Sort();

                return idPlayersList;
            }
            catch (Exception) {

                throw new Exceptions.TeamNotFoundException();
            }
        }

        public long GetBestTeamPlayer(long teamId)
        {
            try
            {
                List<Player> teamPlayers = _players.Where(x => x.teamId == teamId).ToList();

                teamPlayers = teamPlayers.OrderByDescending(x => x.skillLevel).ToList();

                return teamPlayers[0].id;
            }
            catch (Exception) {

                throw new Exceptions.TeamNotFoundException();
            
            }
        }

        public long GetOlderTeamPlayer(long teamId)
        {
            try
            {
                List<Player> teamPlayers = _players.Where(x => x.teamId == teamId).ToList();

                teamPlayers = teamPlayers.OrderBy(x => x.bithDate).ToList();

                return teamPlayers[0].id;
            }
            catch (Exception) {
                throw new Exceptions.TeamNotFoundException();
            }
        }

        public List<long> GetTeams()
        {
            
            List<long> listIdTeam = _teams.Select(x => x.id).ToList();
            listIdTeam.Sort();
            return listIdTeam;
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            try
            {
                int i = 0;
                long idHigherSalaryPlayer;

                List<Player> ListPlayers = _players.Where(x => x.teamId == teamId).ToList();

                ListPlayers = ListPlayers.OrderByDescending(x => x.salary).ToList();
                idHigherSalaryPlayer = ListPlayers[0].id;

                while (ListPlayers[i].salary == ListPlayers[i + 1].salary)
                {

                    if (ListPlayers[i + 1].id < ListPlayers[i].id)
                    {

                        idHigherSalaryPlayer = ListPlayers[i + 1].id;
                    }
                    i++;
                }

                return idHigherSalaryPlayer;
            }
            catch (Exception) { 

                throw new Exceptions.TeamNotFoundException();

            }
        }

        public decimal GetPlayerSalary(long playerId)
        {
            try
            {
                List<Player> player = _players.Where(x => x.id == playerId).ToList();
                return player[0].salary;
            }
            catch (Exception) {

                throw new Exceptions.PlayerNotFoundException();
            }
        }

        public List<long> GetTopPlayers(int top)
        {
            List<long> idsReturn = new List<long>();

            try
            {

                List<Player> playersSorted = _players.OrderByDescending(x => x.skillLevel).ToList();

                playersSorted = playersSorted.Take(top).ToList();

                for (int i = 0; i < playersSorted.Count -1 ; i++)
                {

                    if (i + 1 == playersSorted.Count - 1)
                    {

                        if (playersSorted[i].skillLevel == playersSorted[i + 1].skillLevel)
                        {

                            if (playersSorted[i + 1].id < playersSorted[i].id)
                            {
                                idsReturn.Add(playersSorted[i + 1].id);
                                idsReturn.Add(playersSorted[i].id);
                            }
                            else
                            {
                                idsReturn.Add(playersSorted[i].id);
                                idsReturn.Add(playersSorted[i + 1].id);
                            }
                        }
                        else
                        {
                            idsReturn.Add(playersSorted[i].id);
                            idsReturn.Add(playersSorted[i + 1].id);
                        }

                    }
                    else
                    {
                        if (playersSorted[i].skillLevel == playersSorted[i + 1].skillLevel)
                        {

                            if (playersSorted[i + 1].id < playersSorted[i].id)
                            {
                                idsReturn.Add(playersSorted[i + 1].id);
                            }
                            else
                            {
                                idsReturn.Add(playersSorted[i].id);
                            }
                        }
                        else
                        {
                            idsReturn.Add(playersSorted[i].id);
                        }
                    }
                }
                return idsReturn;
            }
            catch (Exception)
            {
                return idsReturn;
            }
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            try
            {
                List<Team> homeTeam = _teams.Where(x => x.id == teamId).ToList();
                List<Team> visitorTeam = _teams.Where(x => x.id == visitorTeamId).ToList();

                if (homeTeam[0].mainShirtColor == visitorTeam[0].mainShirtColor)
                {

                    return visitorTeam[0].secondaryShirtColor;
                }
                else
                {
                    return visitorTeam[0].mainShirtColor;
                }
            }
            catch (Exception) {

                throw new Exceptions.TeamNotFoundException();
            }
        }

    }
}
