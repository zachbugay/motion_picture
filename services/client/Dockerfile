# base image
FROM node:14.17.1-alpine

EXPOSE 8080
# set working directory
RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app

# install and cache app dependencies.
COPY package.json /usr/src/app/package.json
COPY yarn.lock /usr/src/app/yarn.lock
COPY . /usr/src/app
RUN yarn install
RUN yarn global add @vue/cli@4.5.13

# add `/usr/src/app/node_modules/.bin` to $PATH
ENV PATH /usr/src/app/node_modules/.bin:$PATH

# start app
CMD ["yarn", "serve"]
