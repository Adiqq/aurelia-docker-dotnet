FROM centos

RUN curl --silent --location https://rpm.nodesource.com/setup_6.x | bash -
RUN yum -y install nodejs
RUN yum -y install gcc-c++ make
RUN yum -y install git

RUN npm install -g gulp
RUN npm install -g jspm

WORKDIR /front

EXPOSE 9000/tcp
EXPOSE 3001/tcp

ADD ./init.sh /
RUN chmod +x /init.sh

WORKDIR /



ENTRYPOINT ["bash", "./init.sh"]