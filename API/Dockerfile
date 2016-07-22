FROM centos

RUN yum install -y libunwind libicu
RUN curl -sSL -o dotnet.tar.gz https://go.microsoft.com/fwlink/?LinkID=809131
RUN mkdir -p /opt/dotnet && tar zxf dotnet.tar.gz -C /opt/dotnet
RUN ln -s /opt/dotnet/dotnet /usr/local/bin
RUN rm dotnet.tar.gz

EXPOSE 5000/tcp

ENV USE_POLLING_FILE_WATCHER=true
ENV DOTNET_USE_POLLING_FILE_WATCHER=true
WORKDIR /
ADD ./init.sh /
RUN chmod +x /init.sh

ENTRYPOINT ["bash", "./init.sh"]
