using System;
using System.Collections.Generic;

public class Department
{
	private int NumWorkers;
	private List<Worker> Workers { get; set; }
	private List<Client> ClientQueue { get; set; }
	public Department(in int NumWorkers)
	{
		this.NumWorkers = NumWorkers;
		Workers = new List<Worker>();
		for (int i = 0; i <= NumWorkers; ++i)
        {
			Workers.Add(new Worker());
        }
		ClientQueue = new List<Client>();
	}

	public Client SpawnClient()
    {
		var client = new Client();
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
			freeWorker.Status = Worker.Statuses.BUSY;
			freeWorker.CurrentClient = client;
			client.Worker = freeWorker;
			client.Status = Client.Statuses.PROCESSING;
        }
		return client;

    }
}
