# Stage 1: Build the Angular app
FROM node:latest as build-stage

WORKDIR /app

COPY package.json package-lock.json /app/

RUN npm install

COPY . .

RUN npm run build -- --prod

# Stage 2: Serve the Angular app using nginx
FROM nginx:latest

COPY --from=build-stage /app/dist/ /usr/share/nginx/html

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
