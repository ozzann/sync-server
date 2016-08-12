FROM mono
ADD . /usr/src/app
RUN mcs /usr/src/app/sync_server/Program.cs

EXPOSE 9000
CMD [ "mono", "/usr/src/app/sync_server/Program.exe" ]
