# redisCache-MongoDB
[![.NET](https://github.com/developer-onizuka/redisCache-MongoDB/workflows/.NET/badge.svg)](https://github.com/developer-onizuka/redisCache-MongoDB/actions/workflows/dotnet.yml)
[![Docker Image CI](https://github.com/developer-onizuka/redisCache-MongoDB/workflows/Docker%20Image%20CI/badge.svg)](https://github.com/developer-onizuka/redisCache-MongoDB/actions/workflows/docker-image.yml)

Create a system using redisCache as a search engine of MongoDB's records.


Before doing it, You can choose any of the two Redis™ Helm charts for deploying a Redis™ cluster.

- Redis™ Helm Chart will deploy a master-slave cluster, with the option of enabling using Redis™ Sentinel.<br>
- Redis™ Cluster Helm Chart will deploy a Redis™ Cluster topology with sharding.

My choise is Redis itself not Redis cluster.


# 0. Install Redis
> https://github.com/developer-onizuka/redisCache#2-deploying-redis-on-kubernetes-with-helm


# 1. Set Environment of Redis Server and password
```
export REDIS="192.168.33.223:6379"
export REDIS_PASSWD=$(kubectl get secret --namespace default redis -o jsonpath="{.data.redis-password}" | base64 --decode)
export REDIS_TTL="30"
```
```
$ kubectl exec -it redis-master-0 -- redis-cli -a $REDIS_PASSWD
Warning: Using a password with '-a' or '-u' option on the command line interface may not be safe.
127.0.0.1:6379> ping
PONG
```

# 2. Run MongoDB
```
$ docker run -d --rm -p 27017:27017 --name mongodb mongo:latest
```

# 3. Run redisCache aware App
```
$ git clone https://github.com/developer-onizuka/redisCache-MongoDB
$ cd redisCache-MongoDB
$ dotnet run
```

# 4. Access to localhost:5001/Home
Add some Employees into MongoDB.<br>
The following code sets 30 seconds as an expiration time while adding records.
```
		private int ttl = 30;
                    ...
			string json = JsonConvert.SerializeObject(entity);
			cache.StringSet(entity.EmployeeID.ToString(), json);
			cache.KeyExpire(entity.EmployeeID.ToString(), new TimeSpan(0,0,ttl));
```
<br>
<img src="https://github.com/developer-onizuka/redisCache-MongoDB/blob/main/redisCache-MongoDB1.png" width="520"> <br>

# 5. Search DB for some ids
- First access is a miss hit (if it is after 30 seconds from the initial write), but the app retrives the data from MongoDB. 
<br>
<img src="https://github.com/developer-onizuka/redisCache-MongoDB/blob/main/redisCache-MongoDB2.png" width="640"> <br>
<br>

- So next time, the access will be hit, if the access is within 30 seconds from the first access.
<br>
<img src="https://github.com/developer-onizuka/redisCache-MongoDB/blob/main/redisCache-MongoDB3.png" width="505"> <br>


# 6. Build Container
```
$ docker build . --file Dockerfile --tag employee2:2.0.0
```
```
$ docker run --rm -it -p 5001:5001 -p 5000:5000 --env MONGO="172.17.0.2:27017" --env REDIS="192.168.33.223:6379" --env REDIS_PASSWD="XXXXXXXXXX" --env REDIS_TTL="10" --name employee employee2:2.0.0
```

# 7. Push it to dockerhub
See https://github.com/developer-onizuka/docker_push .

