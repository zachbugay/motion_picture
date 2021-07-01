# base image
FROM node:14.17.1-alpine

# set working directory
RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app

# install and cache app dependencies.
COPY package.json /usr/src/app/package.json
RUN yarn install
RUN yarn install @vue/cli@4.5.13 -g

# add `/usr/src/app/node_modules/.bin` to $PATH
ENV PATH /usr/src/app/node_modules/.bin:$PATH

# start app
CMD ["yarn", "serve"]
