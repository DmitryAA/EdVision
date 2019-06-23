<template>
	<div v-bem>
		<h1>Моё будущее</h1>
		<nav v-bem.links>
			<router-link to="/universities" v-bem.item>Вузы</router-link>
			<router-link to="/companies" v-bem.item>Компании</router-link>
			<router-link to="/projects" v-bem.item>Проекты</router-link>
		</nav>
<!--		<yandexMap :coords="[54.193122, 37.617348]" :zoom="5" style="height:500px"></yandexMap>-->
	</div>
</template>

<script>
	import { yandexMap, ymapMarker } from 'vue-yandex-maps'

	export default {
		name: 'main-page',
		components: {yandexMap, ymapMarker}
	};
</script>
