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

# 2. 



