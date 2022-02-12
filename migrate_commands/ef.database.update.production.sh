# CI向けmigration実行スクリプト
# 接続先は、appsettings.CI.jsonを参照します。

export PATH="$PATH:/root/.dotnet/tools"
export ASPNETCORE_ENVIRONMENT=CIProduction && cd ./src && dotnet ef database update
echo "done"