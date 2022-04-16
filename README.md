# redisCache-MongoDB

You can choose any of the two Redis™ Helm charts for deploying a Redis™ cluster.

Redis™ Helm Chart will deploy a master-slave cluster, with the option of enabling using Redis™ Sentinel.<br>
Redis™ Cluster Helm Chart will deploy a Redis™ Cluster topology with sharding.



# 0. Install Redis (not Redis Cluster)
> https://github.com/developer-onizuka/redisCache#2-deploying-redis-on-kubernetes-with-helm


# 1. Set Environment of Redis Server and password
```
export REDIS="192.168.33.223:6379"
export PASSWD=$(kubectl get secret --namespace default redis -o jsonpath="{.data.redis-password}" | base64 --decode)
```
```
$ kubectl exec -it redis-master-0 -- redis-cli -a $PASSWD
Warning: Using a password with '-a' or '-u' option on the command line interface may not be safe.
127.0.0.1:6379> ping
PONG
```

# 2. Run MongoDB
```
$ docker run -d --rm -p 27017:27017 --name mongodb mongo:latest
```

# 3. Dotnet run
```
$ git clone https://github.com/developer-onizuka/redisCache-MongoDB
$ cd redisCache-MongoDB
$ dotnet run
```

# 4. Access tp https://localhost:5001/Home
Add some Employees into MongoDB.

# 5. Search DB for some ids
First access is a miss hit. However, the second access is a cache hit.

<img src="https://github.com/developer-onizuka/redisCache-MongoDB/blob/main/redisCache-MongoDB1.png" width="640"> <br>
<img src="https://github.com/developer-onizuka/redisCache-MongoDB/blob/main/redisCache-MongoDB2.png" width="640"> <br>
<img src="https://github.com/developer-onizuka/redisCache-MongoDB/blob/main/redisCache-MongoDB3.png" width="640"> <br>
