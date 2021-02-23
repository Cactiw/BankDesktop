using System;

public class Worker
{
	public enum Statuses { READY, BUSY }
	public Statuses Status { get; set; }
	public Client CurrentClient { get; set; }
	public Worker()
	{
		Status = Statuses.READY;
	}
}
