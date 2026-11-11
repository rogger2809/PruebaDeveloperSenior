FROM mcr.microsoft.com/mssql/server:2022-latest

USER root

COPY database /scripts

COPY init.sh /init.sh

RUN chmod +x /init.sh

CMD /bin/bash /init.sh & /opt/mssql/bin/sqlservr