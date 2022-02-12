export PATH="$PATH:/root/.dotnet/tools"
cd ./src && dotnet ef migrations remove --context AppDbContext
echo "done"