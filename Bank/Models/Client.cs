
using System;

public class Client
{
	public enum Statuses { NEW, QUEUE, PROCESSING, DONE, LEFT }
	public Statuses Status { get; set; }
	public Worker Worker { get; set; }
	public int Number { get; }
	public int TimeToSolve { get; set; }
	public Client(int number, int TimeToSolve)
	{
		Status = Statuses.NEW;
		this.Number = number;
		this.TimeToSolve = TimeToSolve;
	}
}
