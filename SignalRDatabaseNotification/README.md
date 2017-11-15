# SignalR
It's a  library for .NET developers that makes developing real-time web functionality easy. SignalR allows bi-directional communication between server and client. Servers can now push content to connected clients instantly as it becomes available. 

# SqlDependency
It's an object associated to a sql command in order to detect when  query results have changed. SQL dependency relia a SQLConnection that is open in orde to be notified when the query has changed.

# Sql service broker
SQL service broker allows  messaging and queuing applications in the SQL Server Database Engine.

# How it works
SqlDependency opens a new connection and register in SQL server a new query in order to be notified when this query changes. When any changes has been detected by SQL server, it sends a notification to the aplication registered. You can get the event OnChange 



# Info links
- https://www.asp.net/signalr
- https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql/detecting-changes-with-sqldependency
- https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql/enabling-query-notifications
- https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-service-broker
