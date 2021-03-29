using System;
using System.Collections.Generic;
using System.Diagnostics;

public class Department
{
	public int NumWorkers;
	public int QueueLimit;
	public List<Worker> Workers { get; }
	public List<Client> ClientQueue { get; }
	public List<int> ClientsWent { get; set; } = new List<int>();
	public Department(in int NumWorkers, in int queueLimit)
	{
		this.NumWorkers = NumWorkers;
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
				Trace.WriteLine("Queue is full! Client left.");
            }
        } else
        {
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
    }
}
