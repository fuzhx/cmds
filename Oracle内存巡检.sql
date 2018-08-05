SELECT * FROM (
(select round((1-(sum(reloads)/sum(pins)))*100,2) "结果",'Library Cache命中率 大于99％' as "标准",'alter system set shared_pool_size=设定值 scope=spfile;' as "处理措施" 
from v$librarycache)
UNION ALL
(select round((1 - (phy.value / (cur.value + con.value)))*100,2) "结果",'Data Buffer（数据缓冲区）命中率 大于90％' as "标准",'alter system set db_cache_size=设定值 scope=spfile;' as "处理措施" 
from v$sysstat cur, v$sysstat con, v$sysstat phy where cur.name = 'db block gets' and con.name = 'consistent gets' and phy.name = 'physical reads')
UNION ALL
(select round((1 - (sum(getmisses) / sum(gets)))*100,2) "结果",'Dictionary Cache命中率 大于95％' as "标准",'alter system set shared_pool_size=设定值 scope=spfile;' as "处理措施"
from v$rowcache )
UNION ALL
(select round(((req.value * 5000) / entries.value),2) "结果",'Log Buffer命中率 小于1%' as "标准",'alter system set log_buffer=设定值 scope=spfile;' as "处理措施"
 from v$sysstat req, v$sysstat entries
 where req.name = 'redo log space requests'
 and entries.name = 'redo entries')
);

