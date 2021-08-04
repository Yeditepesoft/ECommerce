using System;
using System.Linq;
using Core.Exceptions;
using StackExchange.Redis;

namespace Core.Plugins.Caching.Redis
{
    public class RedisServer : IRedisServer
    {
        private readonly RedisOption _redisOption;

        private ConnectionMultiplexer _connectionMultiplexer;

        public RedisServer(RedisOption redisOption)
        {
            _redisOption = redisOption;
            Connect();
        }

        private void Connect()
        {
            if (string.IsNullOrEmpty(_redisOption.ConnectionString)) throw new NotFoundException("Redis Option Not Found");
            try
            {
                _connectionMultiplexer = ConnectionMultiplexer.Connect(_redisOption.ConnectionString);
            }
            catch (Exception e)
            {
                throw new ConnectionException(e.Message);
            }

            if (_connectionMultiplexer == null) throw new ConnectionException("Redis Server Not Connected");
        }

        public IServer GetServer()
        {
            return _connectionMultiplexer.GetServer(_connectionMultiplexer.GetEndPoints().FirstOrDefault());

            /*Old Methods*/
            /*
              var connection = ConnectionMultiplexer.Connect(_option.ConnectionString);
              return connection.GetServer(connection.GetEndPoints().FirstOrDefault());
            */
        }

        public IDatabase GetDb(int db)
        {
            return _connectionMultiplexer.GetDatabase(db);
        }

        public void FlushDatabase(int db)
        {
            _connectionMultiplexer.GetServer(_redisOption.ConnectionString).FlushDatabase(db);
        }
    }
}