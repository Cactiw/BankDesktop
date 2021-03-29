using System;

public class Worker
{
	public enum Statuses { READY, BUSY }
	public Statuses Status { get; set; }
	public Client CurrentClient { get; set; }
	public int Progress { get; set; }
	public int Number { get; }
	public Worker(int number)
	{
		Number = number;
		Status = Statuses.READY;
		Progress = 0;
	}

	public void StartWorkWithClient(Client client)
    {
		this.Status = Worker.Statuses.BUSY;
		this.CurrentClient = client;
		client.Worker = this;
		client.Status = Client.Statuses.PROCESSING;
	}

	public void ProceedWork(int TickRate)
    {
		if (this.Status == Worker.Statuses.READY)
		{
			return;
		}
		this.Progress += TickRate;
		if (this.Progress >= this.CurrentClient.TimeToSolve)
		{
			this.CurrentClient.Status = Client.Statuses.DONE;
			this.CurrentClient = null;
			this.Status = Worker.Statuses.READY;
		}
	}
	public bool IsBusy()
    {
		return Status == Statuses.BUSY;
    }
}
