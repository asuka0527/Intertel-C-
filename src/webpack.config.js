const { VueLoaderPlugin } = require("vue-loader");

var path = require('path')
var webpack = require('webpack')

module.exports = {
  mode: "development",
  entry: { 
      "wwwroot/js/dist/view_login.app": './ts/view_login.ts',
      "wwwroot/js/dist/view_menu.app": './ts/view_menu.ts',
      "wwwroot/js/dist/view_bms_import.app": './ts/view_bms_import.ts',
      "wwwroot/js/dist/view_bms_export.app": './ts/view_bms_export.ts',
      "wwwroot/js/dist/view_data_edit.app": './ts/view_data_edit.ts',
      "wwwroot/js/dist/view_shop_list.app": './ts/view_shop_list.ts',
      "wwwroot/js/dist/view_shop_detail.app": './ts/view_shop_detail.ts',
      "wwwroot/js/dist/view_item_list.app": './ts/view_item_list.ts',
      "wwwroot/js/dist/view_item_create.app": './ts/view_item_create.ts',
      "wwwroot/js/dist/view_item_detail.app": './ts/view_item_detail.ts',

  },
  output: {
    path: path.resolve(__dirname, ''),
    publicPath: '/dist/',
    filename: '[name].bundle.js'
  },
  module: {
    rules: [
      {
        test: /\.vue$/,
        loader: 'vue-loader',
        options: {
          loaders: {
            // Since sass-loader (weirdly) has SCSS as its default parse mode, we map
            // the "scss" and "sass" values for the lang attribute to the right configs here.
            // other preprocessors should work out of the box, no loader config like this necessary.
            'scss': 'vue-style-loader!css-loader!sass-loader',
            'sass': 'vue-style-loader!css-loader!sass-loader?indentedSyntax',
            'js': 'awesome-typescript-loader?silent=true'
          }
          // other vue-loader options go here
        }
      },
      { 
        test: /\.ts$/, 
        include: /ts\/components\/admin/, 
        use: 'awesome-typescript-loader?silent=true' 
      },
      {
        test: /\.tsx?$/,
        loader: 'ts-loader',
        exclude: /node_modules/,
        options: {
          appendTsSuffixTo: [/\.vue$/],
        }
      },
      {
        test: /\.(png|jpg|gif|svg)$/,
        loader: 'file-loader',
        options: {
          name: '[name].[ext]?[hash]'
        }
      },
      {
        test: /\.css$/,
        use: [
          "style-loader",
          "css-loader"
        ]
      },
      {
        test: /\.scss/, // 対象となるファイルの拡張子
        use: [
          "style-loader",
          {
            loader: "css-loader",
            options: {
              url: false,
              importLoaders: 2
            }
          },
          {
            loader: "sass-loader",
            options: {
            }
          }
        ]
      }
    ]
  },
  resolve: {
    extensions: ['.ts', '.js', '.vue', '.json'],
    alias: {
      'vue$': 'vue/dist/vue.esm.js'
    }
  },
  devServer: {
    historyApiFallback: true,
    noInfo: true
  },
  performance: {
    hints: false
  },
  devtool: 'source-map',
  plugins: [
      // make sure to include the plugin for the magic
      new VueLoaderPlugin(),
      new webpack.DefinePlugin({
        'process.env.NODE_ENV': JSON.stringify(process.env.NODE_ENV ? process.env.NODE_ENV : "development")
      }),
  ]
}

if (process.env.NODE_ENV === 'production') {
  module.exports.devtool = '#source-map'
  // http://vue-loader.vuejs.org/en/workflow/production.html
  module.exports.plugins = (module.exports.plugins || []).concat([
    new webpack.DefinePlugin({
      'process.env': {
        NODE_ENV: '"production"'
      }
    }),
    new webpack.LoaderOptionsPlugin({
      minimize: true
    })
  ])
} 
