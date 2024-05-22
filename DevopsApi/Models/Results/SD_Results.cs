using CCapi.Models.CodingChallenge;

using Microsoft.Extensions.Primitives;

namespace DevopsApi.Models.Results
{
    public class CC_LoginFeedback
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public int Score { get; set; }
        public int Stake { get; set; }
        public bool Admin { get; set; }
        public bool InGame { get; set; }
        public List<CC_Message> Messages { get; set; }
        public List<PlannedMatch> Matches { get; set; }
        public List<Result> Results { get; set; }
        public string Etc { get; set; }

        public CC_LoginFeedback()
        {
            Matches = new();
            Messages = new();
            Results = new();
        }
    }

    public class Result
    {
        public CC_Team HomeTeam { get; set; }
        public CC_Team AwayTeam { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public int BetHomeGoals { get; set;}
        public int BetAwayGoals { get; set;}
        public bool Playoff { get; set; }
        public CC_Team Winner { get; set; }
        public bool Shootout { get; set; }
        public int Score { get; set; }

    }
    public class PlannedMatch
    {
        public MatchState State { get; set; }

    }
    public enum DeskState { Free, Mine, Reserved, Fix, MyFix, Inactive }

    public enum UserLevel {  Unregistered, Normal, TeamLeader, DevOps, SuperUser}

    public enum DeskFixState { Free, CanBeBookedLater, Reserved, Mine, Inactive}

    public class UserData
    {
        public int? UserId { get; set; }
        public string? Username { get; set; }
        public string? UserFullName { get; set; }
        public int? ReservationsToLeft { get; set; }
        public string etc { get; set; }
        public UserLevel Role { get; set; } = UserLevel.Unregistered;
        public string RoleName { get; set; }
        public string? TeamName { get; set; }
        public string? FixDesk { get; set; }
    }

    public class OfficeAreaItem
    {
        public string? OfficeArea { get; set; }
        public int? OfficeAreaId { get; set; }
        public int Cols { get; set; }
        public string FileName { get; set; }
    }

    public class TeamData
    {
        public int? TeamId { get; set; }
        public string? Team { get; set; }
        public List<OfficeAreaItem> OfficeAreas { get; set; }
    }

    public class SD_LoginFeedback
    {
        public List<UserData> UserFeedback { get; set; }
        public List<TeamData> TeamFeedback { get; set; }
        public List<OfficeAreaItem> LeaderOfficeFeedback { get; set; }
    }

    public class SD_AnonymousLoginFeedback
    {
        public List<OfficeAreaItem> OfficeAreas { get; set; }
        public List<string> Etc { get; set; }

        public SD_AnonymousLoginFeedback()
        {
            OfficeAreas = new List<OfficeAreaItem>();
            Etc = new List<string>();
        }

    }

    public class Others
    {
        public int? ReservationsToLeft { get; set; }
        public string etc { get; set; }
    }

    public class SD_ReservationFeedback
    {
        public int ReservationsToLeft { get; set; }
        public string etc { get; set; }
    }
    public class Person
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        //public string Team { get; set; }
    }

    public class DeskStatus
    {
        public int SeatId { get; set; } 
        public string Name { get; set; }
        public DeskState State { get; set; }
        public string Place { get; set; }
        public Person? Owner { get; set; }
        public int? ReservationId { get; set; }
        public string? Details { get; set; }
    }

    public class SD_Status
    {
        public List<DeskStatus> Desks { get; set; }
        public List<Others> OtherInfo { get; set; }
    }

    public class ActiveReservations
    {
        public int ReservationId { get; set; }
        public string Date { get; set; }
        public int OfficeAreaId { get; set; }
        public string OfficeAreaName { get; set; }
        public string DeskName { get; set; }
        public string Reservator { get; set; }
    }

    public class TeamDesk
    {
        public int DeskId { get; set; }
        public string DeskName { get; set; }
        public string? Details { get; set; }
        public string Map { get; set; }
        public int? FixOwnerId { get; set; }
        public string? FixOwnerUserName { get; set; }
        public string? FixOwnerDisplayName { get; set; }
        //public string? FixOwnerTeamName { get; set; }
        public string? FixReservationFrom { get; set; }
        public string? CanBeFixedFrom { get; set; }
        public DeskFixState FixState { get; set; }
    }

    public class TeamMembers
    {
        public string DisplayName { get; set; }
        public string UserName { get; set; }
    }

    public class TeamFixDeskFeedback
    {
        public List<TeamMembers> Members { get; set; }
        public List<TeamDesk> Desk {  get; set; }
        public List<string> etc {  get; set; }
    }

    public class DeskActiveReservations
    {
        public int ReservationId {  get; set; }
        public DateTime ReservationDate { get; set; }
        public string HolderName { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
    }

    public class FixReservationFeedback
    {
        public int CancelledRerservations { get; set; }
        public string Etc { get; set; }
    }

    public class MemberReservation
    {
        public string Date { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public int ReservationId { get; set; }
        public int DeskId { get; set; } = 0;
        public string DeskName { get; set; }
        public bool FixReservation { get; set; }
    }

    public class TeamReservationsFeedback
    {        
        public List<MemberReservation> Reservations { get; set; }
        public string Etc { get; set; }
    }

    public class CalendareDaysFeedback
    {
        public int AvailableDays { get; set; }
        public string LastDay { get; set; }
    }

    public class AllReservationsFeedback
    {
        public List<ActiveReservation> ActiveReservations { get; set; }
        public List<FixReservation> FixReservations { get; set; }
        public List<Reservater> Reservaters { get; set; }
        public List<Team> Teams { get; set; }
        public List<OfficeArea> OfficeAreas { get; set; }
        public List<string> Etc { get; set; }

        public AllReservationsFeedback()
        {
            ActiveReservations = new List<ActiveReservation>();
            FixReservations = new List<FixReservation>();
            Reservaters = new List<Reservater>();
            Teams = new List<Team>();
            OfficeAreas = new List<OfficeArea>();
            Etc = new List<string>();
        }
    }

    public class ActiveReservation
    {
        public string UserDisplayName { get; set; }
        public string TeamName { get; set; }
        public string OfficeAreaName { get; set; }
        public string DeskName { get; set; }
        public string Date { get; set; }
        public DateTime DateDND { get; set; }
    }

    public class FixReservation
    {
        public string OfficeAreaName { get; set; }
        public string DeskFullName { get; set; }
        public string FixOwnerName { get; set; }
        public string TeamName { get; set; }
        public string FromWhen { get; set; }
    }

    public class Reservater
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string TeamName { get; set; }        
    }

    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
    }

    public class OfficeArea
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
    }

}
