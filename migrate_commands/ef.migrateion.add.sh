export PATH="$PATH:/root/.dotnet/tools"
CURRENT_DIR=`pwd`
cd /workspace/src && dotnet ef migrations add "$1" --context AppDbContext
cd $CURRENT_DIR
echo "done"