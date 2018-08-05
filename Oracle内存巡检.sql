SELECT * FROM (
(select round((1-(sum(reloads)/sum(pins)))*100,2) "���",'Library Cache������ ����99��' as "��׼",'alter system set shared_pool_size=�趨ֵ scope=spfile;' as "�����ʩ" 
from v$librarycache)
UNION ALL
(select round((1 - (phy.value / (cur.value + con.value)))*100,2) "���",'Data Buffer�����ݻ������������� ����90��' as "��׼",'alter system set db_cache_size=�趨ֵ scope=spfile;' as "�����ʩ" 
from v$sysstat cur, v$sysstat con, v$sysstat phy where cur.name = 'db block gets' and con.name = 'consistent gets' and phy.name = 'physical reads')
UNION ALL
(select round((1 - (sum(getmisses) / sum(gets)))*100,2) "���",'Dictionary Cache������ ����95��' as "��׼",'alter system set shared_pool_size=�趨ֵ scope=spfile;' as "�����ʩ"
from v$rowcache )
UNION ALL
(select round(((req.value * 5000) / entries.value),2) "���",'Log Buffer������ С��1%' as "��׼",'alter system set log_buffer=�趨ֵ scope=spfile;' as "�����ʩ"
 from v$sysstat req, v$sysstat entries
 where req.name = 'redo log space requests'
 and entries.name = 'redo entries')
);

