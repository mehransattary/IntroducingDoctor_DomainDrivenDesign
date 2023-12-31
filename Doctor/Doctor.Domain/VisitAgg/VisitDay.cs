﻿

using Common.Domain;
using Common.Domain.Exceptions;
using Doctor.Domain.DoctorInformationAgg;

namespace Doctor.Domain.VisitAgg;

public class VisitDay:AggregateRoot
{
    #region Constructor
    private VisitDay()
    {

    }
    public VisitDay(string title, DayEnum day)
    {
        Guard(title);
        this.Title = title;
        this.Day = day;
    }
    #endregion

    #region Properties
    public string Title { get; private set; }
    public DayEnum Day { get; private set; }
    public List<VisitTime> VisitTimes { get; private set; } = new List<VisitTime>();

    #endregion

    #region Methods
    public void Edit(string title, DayEnum day)
    {
        Guard(title);

        this.Title = title;
        this.Day = day;
    }
    public void AddTime(VisitTime visitTime)
    {
        visitTime.VisitDayId = Id;
        VisitTimes.Add(visitTime);
    }
    public void RemoveTime(VisitTime visitTime)
    {
        VisitTimes.Remove(visitTime);
    }
  
    public void Guard(string title)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));     

    }
    #endregion

}
public enum DayEnum
{
    Saturday=1,
    Sunday=2,
    Monday=3,
    Tuesday=4,
    Wednesday=5,    
    Thursday=6, 
    Friday=7,   
}