using System;
using System.Collections.Generic;
using System.Diagnostics;

public class Department
{
	public int NumWorkers;
	public int WorkersSalary;
	public int QueueLimit;
	public List<Worker> Workers { get; }
	public List<Client> ClientQueue { get; }
	public List<int> ClientsWent { get; set; } = new List<int>();

	public int ClientsTotal { get; set; } = 0;
	public int ClientsLeft { get; set; } = 0;
	public int EarnedMoney { get; set; } = 0;
	public float SalaryPaid { get; set; } = 0;
	public Department(in int NumWorkers, in int workersSalary, in int queueLimit)
	{
		this.NumWorkers = NumWorkers;
		this.WorkersSalary = workersSalary;
		this.QueueLimit = queueLimit;
		Workers = new List<Worker>();
		for (int i = 0; i < NumWorkers; ++i)
        {
			Workers.Add(new Worker(i + 1));
			ClientsWent.Add(-1);
        }
		ClientQueue = new List<Client>();
	}

	public void NewClient(Client client)
    {
		ClientsTotal += 1;
		Worker freeWorker = null;
		for (int i = 0; i < NumWorkers; ++i)
        {
			Worker worker = Workers[i];
			if (worker.Status == Worker.Statuses.READY)
            {
				freeWorker = worker;
				Trace.WriteLine("Got worker num " + i.ToString());
				ClientsWent[i] = client.Number;
				break;
            }
        }
		if (freeWorker == null)
        {
			if (ClientQueue.Count < QueueLimit)
			{
				client.Status = Client.Statuses.QUEUE;
				this.ClientQueue.Add(client);
				Trace.WriteLine("Put client to queue!");
			} else
            {
				client.Status = Client.Statuses.LEFT;
				ClientsLeft += 1;
				Trace.WriteLine("Queue is full! Client left.");
            }
        } else
        {
			EarnedMoney += client.Profit;
			freeWorker.StartWorkWithClient(client);
        }
		return;

    }

	public void TryMoveQueue(Worker worker)
    {
		if (worker.Status != Worker.Statuses.READY)
        {
			return;
        }
		if (this.ClientQueue.Count == 0)
        {
			return;
        }
		Client client = ClientQueue[0];
		ClientQueue.RemoveAt(0);
		worker.StartWorkWithClient(client);
		ClientsWent[worker.Number - 1] = client.Number;

	}

	public void ClearState()
    {
		foreach (Worker worker in Workers)
        {
			worker.ResetWorker();
        }
		ClientQueue.Clear();
    }
	public void Tick(int TickRate)
    {
		Workers.ForEach(worker =>
		{
			worker.ProceedWork(TickRate);
			TryMoveQueue(worker);
		});

		SalaryPaid += WorkersSalary * ((float)TickRate / 60);
    }

	public float GetWorkersBusyStatistics()
    {
		int total = 0;
		int busy = 0;

		Workers.ForEach(worker =>
		{
			total += worker.BusyTime + worker.FreeTime;
			busy += worker.BusyTime;
		});
		if (total == 0)
        {
			return 0;
        }
		return (float)busy / total;
	}
}
