<Query Kind="Program">
  <Connection>
    <ID>e7d0f4d3-3a1d-4d95-9dc7-e78a6dd46da8</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Server>localhost</Server>
    <UserName>admin</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAXvA1BrUQZ0+luY1vz1t2yQAAAAACAAAAAAAQZgAAAAEAACAAAAC1jtPZhQUmghtEDesKvFZ4+aLby/x12foO+QjPtg4aMQAAAAAOgAAAAAIAACAAAACMtGMQtHDHHzuAaqd7qrO++OpFaqfYN8plQdaZeGDCyRAAAADXQ2UxiaYF2z7krRkU8rVBQAAAAPQcPUKvUEgvLUKeMOfhYxV6UP090qTV7cWgjJcVJPDEZZ2/C+1yFXyPx2zpJMUv20KuDMket329XLjTTPUr/EE=</Password>
    <Database>Gevs</Database>
    <DriverData>
      <EncryptSqlTraffic>True</EncryptSqlTraffic>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Npgsql.EntityFrameworkCore.PostgreSQL</EFProvider>
    </DriverData>
  </Connection>
</Query>

public class Seats
{
	public string Party { get; set; }
	public int Seat { get; set; }
}

public class ElectionResult
{
	public string Status { get; set; }
	public string Winner { get; set; }
	public List<Seats> Seats { get; set; } = new List<Seats>();
}

void Main()
{
	var districts = Constituencies.ToList();
	
	ElectionResult electionResult = new ElectionResult();
	
	Seats yellowParty = new Seats() {
		Party = "Yellow Party",
		Seat = 0
	};

	Seats redParty = new Seats()
	{
		Party = "Red Party",
		Seat = 0
	};

	Seats blueParty = new Seats()
	{
		Party = "Blue Party",
		Seat = 0
	};

	Seats independent = new Seats()
	{
		Party = "Indepenent",
		Seat = 0
	};
	
	electionResult.Seats.Add(yellowParty);
	electionResult.Seats.Add(redParty);
	electionResult.Seats.Add(blueParty);
	electionResult.Seats.Add(independent);

	foreach (var district in districts)
	{
		var districtId = district.Id;
		var candidates = Candidates.Where(c => c.ConstituencyId == districtId).ToList();

		try
		{
			var highestVotedCandidate = candidates
				   .Aggregate((highest, next) => next.VoteCount > highest.VoteCount ? next : highest);

			if (highestVotedCandidate != null)
			{

				var partyId = highestVotedCandidate.PartyId;
				var party = Parties.FirstOrDefault(p => p.Id == partyId);

				electionResult.Seats.FirstOrDefault(s => s.Party == party.Name).Seat += 1;
			}
		}
		catch (Exception ex) {
					
		}
	}
	

	var winnerParty = electionResult.Seats.Aggregate((x, y) => x.Seat > y.Seat ? x : y);
	
	var electionStatus = Elections.ToList()[0];
	
	electionStatus.Dump();
	
	electionResult.Status = electionStatus.Ongoing ? "Pending" : "Completed";

	electionResult.Winner = winnerParty.Party;
	
	electionResult.Dump();
}

// You can define other methods, fields, classes and namespaces here