# ローカル向けmigration実行スクリプト
# 接続先は、appsettings.Development.jsonを参照します。

export PATH="$PATH:/root/.dotnet/tools"
CURRENT_DIR=`pwd`
cd /workspace/src && dotnet ef database update --context AppDbContext
cd $CURRENT_DIR
echo "done"

#addImagesInOffice