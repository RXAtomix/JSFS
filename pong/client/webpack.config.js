// fichier webpack.config.js
const path = require('path');
const PRODUCTION = false;
const HtmlWebpackPlugin = require('html-webpack-plugin');
const CopyPlugin = require('copy-webpack-plugin');

module.exports = {
  entry: './src/scripts/pong.js',
  mode : (PRODUCTION ? 'production' : 'development'),
  devtool : (PRODUCTION ? undefined : 'eval-source-map'),
  output: {
    path: path.resolve(__dirname, (PRODUCTION ? '../server/public/' : '../server/public/') ),
    filename: 'scripts/bundle.js'
  },
  plugins: [
    new HtmlWebpackPlugin({
        template: "./src/index.html",
        filename: "./index.html"
    }),
    new CopyPlugin({
        patterns: [
      {
        from: 'src/images/*',
        to:   'images/[name][ext]'
      },
      {
        from: 'src/style/*',
        to:   'style/[name][ext]'
      },
        ]
     })
  ],
  devServer: {
    static: {
       publicPath: path.resolve(__dirname, 'dist'),
       watch : true
    },
    host: 'localhost',
    port : 8080,
    open : true
  },
  module: {
    rules : [
        {
            test: /\.css$/,
            use: [
              { loader: 'style-loader' },
              { loader: 'css-loader' }
            ]
          },
        {
        test: /\.(png|jpg|gif)/i,
        use: [
          {
            loader: 'file-loader',
            options: {
              name : '[name].[ext]',
              outputPath : 'images'
            }
          }
        ]
      }
    ]
  }
}