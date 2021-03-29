using System;
using System.Collections.Generic;

public class Department
{
	private int NumWorkers;
	public List<Worker> Workers { get; }
	public List<Client> ClientQueue { get; }
	public Department(in int NumWorkers)
	{
		this.NumWorkers = NumWorkers;
		Workers = new List<Worker>();
		for (int i = 0; i < NumWorkers; ++i)
        {
			Workers.Add(new Worker(i + 1));
        }
		ClientQueue = new List<Client>();
	}

	public void NewClient(Client client)
    {
		Worker freeWorker = null;
		for (int i = 0; i <= NumWorkers; ++i)
        {
			Worker worker = Workers[i];
			if (worker.Status == Worker.Statuses.READY)
            {
				freeWorker = worker;
				break;
            }
        }
		if (freeWorker == null)
        {
			client.Status = Client.Statuses.QUEUE;
			this.ClientQueue.Add(client);
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

	public void Tick(int TickRate)
    {
		Workers.ForEach(worker =>
		{
			worker.ProceedWork(TickRate);
			TryMoveQueue(worker);
		});
    }
}
