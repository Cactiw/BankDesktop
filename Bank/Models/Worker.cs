﻿using System;
using System.Diagnostics;

public class Worker
{
	public enum Statuses { READY, BUSY }
	public Statuses Status { get; set; }
	public Client CurrentClient { get; set; }
	public int Progress { get; set; }
	public int Number { get; }
	public int BusyTime { get; set; } = 0;
	public int FreeTime { get; set; } = 0;
	public Worker(int number)
	{
		Number = number;
		Status = Statuses.READY;
		Progress = 0;
	}

	public void StartWorkWithClient(Client client)
    {
		this.Progress = 0;
		this.Status = Worker.Statuses.BUSY;
		this.CurrentClient = client;
		client.Worker = this;
		client.Status = Client.Statuses.PROCESSING;
	}

	public void ResetWorker()
    {
		this.Progress = 0;
		this.Status = Worker.Statuses.READY;
		this.CurrentClient = null;
	}

	public void ProceedWork(int TickRate)
    {
		if (this.Status == Worker.Statuses.READY)
		{
			FreeTime += TickRate;
			return;
		}
		BusyTime += TickRate;
		this.Progress += TickRate;
		if (this.Progress >= this.CurrentClient.TimeToSolve)
		{
			this.CurrentClient.Status = Client.Statuses.DONE;
			this.CurrentClient = null;
			this.Status = Worker.Statuses.READY;

			Trace.WriteLine("Work for " + Number.ToString() + " complete!");
		}
	}
	public bool IsBusy()
    {
		return Status == Statuses.BUSY;
    }
}
