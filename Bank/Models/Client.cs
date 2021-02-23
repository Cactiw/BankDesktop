
using System;

public class Client
{
	public enum Statuses { NEW, QUEUE, PROCESSING, DONE, LEFT }
	public Statuses Status { get; set; }
	public Worker Worker { get; set; }
	public Client()
	{
		Status = Statuses.NEW;
	}
}
